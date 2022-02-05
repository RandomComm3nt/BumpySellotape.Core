using System.Collections.Generic;
using System.Linq;

namespace BumpySellotape.Events.Model.Scopes
{
    public abstract class Scope
    {
        public Scope ParentScope { get; private set; }
        public List<Scope> ChildScopes { get; }
        public Scope RootScope => ParentScope == null ? this : ParentScope.RootScope;

        protected Scope(Scope parentScope)
        {
            ParentScope = parentScope;
            if (parentScope != null)
                parentScope.RegisterChildScope(this);
            ChildScopes = new List<Scope>();
        }

        public void RegisterChildScope(Scope scope)
        {
            ChildScopes.Add(scope);
        }

        public TScope GetHigherScope<TScope>()
            where TScope : Scope
        {
            if (this is TScope s)
                return s;
            if (ParentScope == null)
                return null;
            return ParentScope.GetHigherScope<TScope>();
        }

        public void SetParentScope(Scope scope)
        {
            // TECH DEBT - unregister previous parent
            ParentScope = scope;
            scope.RegisterChildScope(this);
        }

        public void RemoveChild(Scope scope)
        {
            ChildScopes.Remove(scope);
            scope.ParentScope = null;
        }

        public List<Scope> GetAllChildScopes()
        {
            return new List<Scope>() { this }
                .Union(ChildScopes.SelectMany(s => s.GetAllChildScopes()))
                .ToList();
        }

        public List<TScope> GetAllLowerScopes<TScope>()
            where TScope : Scope
        {
            return GetAllChildScopes()
                .Where(s => s is TScope)
                .Select(s => s as TScope)
                .ToList();
        }
    }
}
