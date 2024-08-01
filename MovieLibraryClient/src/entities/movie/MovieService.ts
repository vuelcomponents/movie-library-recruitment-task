import {Service} from "../../shared/services/Service.ts";
import {TinyEmitter} from "tiny-emitter";
import {Movie} from "./Movie.ts";

export class MovieService extends Service<Movie>{
    constructor(emitter:TinyEmitter) {
        super(emitter);
    }
}