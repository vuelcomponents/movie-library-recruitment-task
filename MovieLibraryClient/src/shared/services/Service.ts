import useInterceptors from "./useInterceptors";
import type { AxiosInstance } from "axios";
import axios from "axios";
import type { TinyEmitter } from "tiny-emitter";
import { getAssociatedUrl } from "../resources/urls.ts";

export abstract class Service {
  emitter: TinyEmitter;
  host = getAssociatedUrl("movie-library-server");
  path?: string;
  http: AxiosInstance = axios;

  constructor(emitter: TinyEmitter) {
    this.http.defaults.withCredentials = true;
    this.emitter = emitter;
    useInterceptors({ client: this.http, emitter });
  }

  async getAll() {
    return await this.http.get(`${this.host}/${this.path}/get`);
  }

  async getById(id: number) {
    return await this.http.get(`${this.host}/${this.path}/get/${id}`);
  }

  async create(object: any) {
    return await this.http.post(`${this.host}/${this.path}/create`, object);
  }

  async update(object: any) {
    return await this.http.patch(`${this.host}/${this.path}/update`, object);
  }

  async delete(id: number) {
    return await this.http.delete(`${this.host}/${this.path}/delete/${id}`);
  }

  async deleteMany(list: Array<any>) {
    return await this.http.post(`${this.host}/${this.path}/delete-many`, list);
  }
}
