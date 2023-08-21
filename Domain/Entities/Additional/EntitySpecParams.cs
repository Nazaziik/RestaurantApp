namespace Domain.Entities.Additional
{
    public class EntitySpecParams
    {
        private int _maxPageSize = 50;
        public int MaxPageSize { get { return _maxPageSize; } set { _maxPageSize = value; } }

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; } }

        public int? TypeId { get; set; }

        public string Sort { get; set; }
    }
}