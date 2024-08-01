import type {
  CellClickedEvent,
  CellValueChangedEvent,
} from "ag-grid-community";

export abstract class GridDefaults {
  protected readonly defaultOnCellClicked = (params: CellClickedEvent) => {
    console.warn("GRID CL: on cell clicked has not been implemented", params);
  };
  protected readonly defaultOnCellValueChanged = (
    params: CellValueChangedEvent,
  ) => {
    console.warn(
      "GRID CL: on cell value changed has not been implemented",
      params,
    );
  };
  protected readonly defaultLoadList = async () => {
    console.warn("GRID CL: Load List has not been implemented");
  };
}
