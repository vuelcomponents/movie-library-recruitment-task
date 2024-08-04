import defaultColDef from "./grid-composables/defaultColDef.ts";
import type {
  GridApi,
  GridOptions,
  GridReadyEvent,
  SelectionChangedEvent,
} from "ag-grid-community";
import { IGrid } from "./grid-interfaces/IGrid.ts";
import { IGridEvents } from "./grid-interfaces/grid-detail-interfaces/IGridEvents.ts";
import { Identified } from "../types/Identified.ts";
import { GridDefaults } from "./GridDefaults.ts";

export class Grid<T> extends GridDefaults implements IGrid<T> {
  api?: GridApi<Identified<T>>;
  selected: Array<Identified<T>> = new Array<Identified<T>>();
  searchText = "";
  options: GridOptions<Identified<T>>;
  data: Array<Identified<T>> = new Array<Identified<T>>();
  loadList: () => Promise<void>;

  private readonly onSelectionChanged = (params: SelectionChangedEvent) => {
    if (!params.api.isDestroyed()) this.selected = params.api.getSelectedRows();
  };

  /* Konstruktor jest uzywany do zadeklorawania wlasnych metod, jesli chcesz zastapic defaultowe */
  constructor({
    events = {},
    functions = {},
  }: {
    events?: IGridEvents;
    functions?: any;
  }) {
    super();

    this.loadList = functions?.loadList ?? this.defaultLoadList;
    this.options = {
      // pagination: true,
      // paginationPageSize: 20,
      onGridReady: async (params: GridReadyEvent) => {
        this.api = params.api;
        await this.loadList();
      },
      onCellValueChanged:
        events?.onCellValueChanged ?? this.defaultOnCellValueChanged,
      onCellClicked: events?.onCellClicked ?? this.defaultOnCellClicked,
      onSelectionChanged: this.onSelectionChanged,
      defaultColDef,
    };
  }
}
