import type { NewValueParams, CellClickedEvent } from "ag-grid-community";
export interface IGridEvents {
  onCellValueChanged?: (event: NewValueParams) => void;
  onCellClicked?: (event: CellClickedEvent) => void;
}
