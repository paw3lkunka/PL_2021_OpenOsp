namespace OpenOsp.Model.Filters {
  
  public class PaginationFilter {

    private const int MAX_PAGE_SIZE = 10;

    private int _pageIndex = 1;

    private int _pageSize = MAX_PAGE_SIZE;

    public int PageIndex {
      get => _pageIndex; 
      set => _pageIndex = (value < 1) ? 1 : value;
    }

    public int PageSize {
      get => _pageSize;
      set => _pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
    }

  }
  
}