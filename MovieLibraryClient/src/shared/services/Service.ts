import useInterceptors from "./useInterceptors";
import type { AxiosInstance, AxiosResponse } from "axios";
import axios from "axios";
import type { TinyEmitter } from "tiny-emitter";
import { getAssociatedUrl } from "../resources/urls.ts";
import {Identified} from "../types/Identified.ts";

export abstract class Service<T> {
  emitter: TinyEmitter;
  host = getAssociatedUrl("movie-library-server");
  path?: string;
  http: AxiosInstance = axios;

  protected constructor(emitter: TinyEmitter) {
    this.http.defaults.withCredentials = true;
    this.emitter = emitter;
    useInterceptors({ client: this.http, emitter });
  }

  getAll(): Promise<AxiosResponse<Array<Identified<T>>>> {
    return this.http.get(`${this.host}/${this.path}/get`);
  }

  getById(id: number): Promise<AxiosResponse<Identified<T>>> {
    return this.http.get(`${this.host}/${this.path}/get/${id}`);
  }

  create(object: any): Promise<AxiosResponse<Identified<T>>> {
    return this.http.post(`${this.host}/${this.path}/create`, object);
  }

  update(object: any): Promise<AxiosResponse<Identified<T>>> {
    return this.http.patch(`${this.host}/${this.path}/update`, object);
  }

  delete(id: number): Promise<AxiosResponse<any>> {
    return this.http.delete(`${this.host}/${this.path}/delete/${id}`);
  }

  deleteMany(list: Array<any>): Promise<AxiosResponse<any>> {
    return this.http.post(`${this.host}/${this.path}/delete-many`, list);
  }
}
