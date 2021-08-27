using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            
        }
        Expression<Func<T, bool>> ISpecifications<T>.Criteria {get; }
        public List<Expression<Func<T, object>>> Includes  {get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> inludeExpression){

            Includes.Add(inludeExpression);
        }
    }
}