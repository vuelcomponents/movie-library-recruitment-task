import { IGrid } from "./IGrid.ts";

export interface IGridPlus<T> extends IGrid<T> {
  selectedToIds: Function;
  deleteRowsByParam: (param: string, value: any) => void;
  updateRowByParam: (param: any, value: any, data: any) => void;
  updateRowById: (id: number, data: any) => void;
  deleteRowsByParamMany: (param: string, values: any[]) => void;
  getAllRows: () => Array<T>;
  deleteSelectedRows: () => void;
  deleteRowsByIds: (idDtos: { id: number }[]) => void;
  search: () => void;
}
