import {Service} from "../../shared/services/Service.ts";
import {TinyEmitter} from "tiny-emitter";
import {Movie} from "./Movie.ts";
import type {AxiosResponse} from "axios";
import {Identified} from "../../shared/types/Identified.ts";

export class MovieService extends Service<Movie>{
    path = "movie";
    constructor(emitter:TinyEmitter) {
        super(emitter);
    }
    integrate(): Promise<AxiosResponse<Array<Identified<Movie>>>> {
        return this.http.get(`${this.host}/${this.path}/integrate`);
    }
}