import type { GridApi, GridOptions } from "ag-grid-community";
import { Identified } from "../../types/Identified.ts";
export interface IGrid<T> {
  api?: GridApi<Identified<T>>;
  data: any;
  selected: Identified<T>[];
  searchText: string;
  loadList: () => void;
  options: GridOptions<Identified<T>>;
}
