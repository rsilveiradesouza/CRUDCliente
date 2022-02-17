using CRUDCliente.Contracts.Queries;
using CRUDCliente.Shared.Enums;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace CRUDCliente.Data.Specifications
{
    public class Query<T> : IQuery<T>
    {
        public Expression<Func<T, bool>> Criteria { get; protected set; }
        public List<Expression<Func<T, object>>> Inclusions { get; } = new();
        public List<string> SubInclusions { get; } = new();
        public List<Expression<Func<T, object>>> ExcludedFields { get; } = new();

        public int PageSize { get; }
        public int PageNumber { get; }
        public string OrderBy { get; }
        public OrderDirection OrderDirection { get; }

        protected Query(Expression<Func<T, bool>> criteria, int pageSize = -1, int pageNumber = 1, string orderBy = "", OrderDirection orderDirection = OrderDirection.DESC)
        {
            Criteria = criteria;
            PageSize = pageSize;
            PageNumber = pageNumber;
            OrderBy = orderBy;
            OrderDirection = orderDirection;
        }

        protected void AddInclusion(Expression<Func<T, object>> inclusion) =>
            Inclusions.Add(inclusion);

        protected void AddSubInclusion<SubInclusionType>(Expression<Func<T, object>> property, Expression<Func<SubInclusionType, object>> subInclusion)
        {
            var expressao = property.ToString();
            var nomePropriedade = expressao.Substring(expressao.IndexOf('.') + 1);
            var expressaoSubInclusao = subInclusion.ToString();
            var caminhoInclusao = expressaoSubInclusao.Substring(expressaoSubInclusao.IndexOf('.') + 1);

            var caminhoCompletoInclusao = $"{nomePropriedade}.{caminhoInclusao}";

            if (caminhoCompletoInclusao.Contains(")") || caminhoCompletoInclusao.Contains("]"))
            {
                caminhoCompletoInclusao = Regex.Replace(caminhoCompletoInclusao, @"\.[a-zA-Z]+\(\)|[\d]", "");
            }

            SubInclusions.Add(caminhoCompletoInclusao);
        }

        protected void AddFieldExclusion(Expression<Func<T, object>> exclusion) =>
            ExcludedFields.Add(exclusion);
    }
}