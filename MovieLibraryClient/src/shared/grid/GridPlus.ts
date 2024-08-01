import { Grid } from "./Grid.ts";
import { Identified } from "../types/Identified.ts";
import type { IRowNode } from "ag-grid-community";
import { IGridEvents } from "./grid-interfaces/grid-detail-interfaces/IGridEvents.ts";
import { IGridPlus } from "./grid-interfaces/IGridPlus.ts";

export class GridPlus<T> extends Grid<T> implements IGridPlus<T> {
  constructor({
    events = {},
    functions = {},
  }: {
    events?: IGridEvents;
    functions?: any;
  }) {
    super({ events, functions });
  }
  getAllRows = (): Array<Identified<T>> => {
    const rowData: Identified<T>[] = [];
    this.api!.forEachNode((node) => rowData.push(node.data!));
    return rowData;
  };

  deleteSelectedRows = () => {
    const data = this.getAllRows().filter(
      (d) => !this.selected.some((r: Identified<T>) => r.id === d.id),
    );
    this.api!.setGridOption("rowData", data);
  };

  deleteRowsByIds = (idDtos: { id: number }[]) => {
    const remove = this.getAllRows().filter(
      (d) => !idDtos.some((r: { id: number }) => r.id === d.id),
    );
    this.api!.applyTransaction({
      remove,
    });
    // this.api!.setGridOption('rowData', remove);
  };

  deleteRowsByParam = (param: string, value: Identified<T>) => {
    const data = this.getAllRows().filter(
      (d: Identified<T>) => d[param as keyof Identified<T>] !== value,
    );
    this.api!.setGridOption("rowData", data);
  };

  deleteRowsByParamMany = (param: string, values: Array<Identified<T>>) => {
    const data = this.getAllRows().filter(
      (d: Identified<T>) =>
        !values.some((value) => d[param as keyof Identified<T>] === value.id),
    );
    this.api!.setGridOption("rowData", data);
  };
  updateRowById = (id: number, data: any) => {
    this.api!.forEachNode((node: IRowNode<Identified<T>>) => {
      if (node.data?.id === id) {
        node.setData(data);
      }
    });
  };
  updateRowByParam = (
    param: string,
    value: Identified<T>,
    data: Identified<T>,
  ) => {
    this.api!.forEachNode((node: IRowNode<T>) => {
      if ((node.data as any)[param] === value) {
        node.setData(data);
      }
    });
  };
  selectedToIds = (): Array<{ id: number }> => {
    const ids: any[] = [];
    this.selected.forEach((s: any) => ids.push({ id: s.id }));
    return ids;
  };
  search = () => {
    this.api!.setGridOption("quickFilterText", this.searchText);
  };
}
