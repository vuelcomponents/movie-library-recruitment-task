import type {App} from "vue";
import {TinyEmitter} from "tiny-emitter";

export function useEmitter(app:App){
    const emitter = new TinyEmitter();
    app.provide('emitter', emitter);
    return emitter;
}