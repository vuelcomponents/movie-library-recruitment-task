import type { TinyEmitter } from "tiny-emitter";
import { MovieService } from "../../entities/movie/MovieService";

interface IServices {
  [key: string]: new (
    emitter: TinyEmitter
  ) => any;
}

export class ServiceInstantiator {
  emitter: TinyEmitter;
  services: IServices = {
    MovieService
  };

  constructor(emitter: TinyEmitter) {
    this.emitter = emitter;
  }

  create<T>(service: any): T | void {
    try {
      switch (typeof service) {
        case "string":
          return new this.services[service](
            this.emitter,
          ) as T;
        default:
          return new service(this.emitter) as T;
      }
    } catch (e) {
      this.emitter.emit("error", "No valid service has been found");
    }
  }
}
