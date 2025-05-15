export interface FilterSettings {
  pageIndex: number;
  pageSize: number;
  sortField: string;
  sortOrder: string;
  filter: any;
}

export interface PaginatedRequest {
  pageIndex?: number;
  pageSize?: number;
  sortOrder?: string;
  fieldFilters?:FieldFilter[];
}

export interface FieldFilter{
  field: string,
  operator?: string,
  value: string
}

export interface PaginatedResult<T> {
  items: T[];
  totalCount: number;
  pageIndex: number;
  pageSize: number;
  totalPages: number;
}

