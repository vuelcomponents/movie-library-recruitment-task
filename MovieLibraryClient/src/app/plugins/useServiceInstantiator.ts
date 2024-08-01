import type {App} from "vue";
import {ServiceInstantiator} from "../../shared/services/ServiceInstantiator.ts";
import {TinyEmitter} from "tiny-emitter";

export function useServiceInstantiator(app:App, emitter:TinyEmitter){
    const serviceInstantiator = new ServiceInstantiator(emitter);
    app.provide<ServiceInstantiator>('ServiceInstantiator', serviceInstantiator);
    return serviceInstantiator;
}