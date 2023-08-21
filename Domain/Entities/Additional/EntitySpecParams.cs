namespace Domain.Entities.Additional
{
    public class EntitySpecParams
    {
        public int MaxPageSize { get; set; } = 50;

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; } }

        public int? TypeId { get; set; }

        public string Sort { get; set; }
    }
}