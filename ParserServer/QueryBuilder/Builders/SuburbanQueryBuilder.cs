using System.Linq;
using ParserServer.QueryBuilder.Exceptions;
using ParserServer.QueryBuilder.Models.Suburban;

namespace ParserServer.QueryBuilder.Builders
{
    public class SuburbanQueryBuilder : BaseQueryBuilder<SuburbanQueryBuilder>
    {
        protected override string OfferType => "&offer_type=suburban";

        private string _objectType =
            "&object_type%5B0%5D=1&object_type%5B1%5D=2&object_type%5B2%5D=3&object_type%5B3%5D=4";

        private string? OfferFilter { get; set; }
        
        public SuburbanQueryBuilder SetObjectsType(params ObjectType[] types)
        {
            var objectTypes = types.Distinct();

            var enumerable = objectTypes as ObjectType[] ?? objectTypes.ToArray();
            
            if (enumerable.Count() <= 4)
            {
                var tempString = "";
                
                for (var i=0; i <= enumerable.Length - 1; i++)
                {
                    tempString += $"&object_type%5B{i}%5D=" + (int) enumerable[i];
                }

                _objectType = tempString;
                
                return this;
            }

            throw new SuburbanObjectTypeException("There are a lot off types");
        }

        public SuburbanQueryBuilder OfferFrom(OfferFilter filter)
        {
            OfferFilter = "&suburban_offer_filter=" + (int) filter;
            return this;
        }
        
       

        public override string Build()
        {
            base.Build();
            
            return Uri += _objectType;
        }
    }
}