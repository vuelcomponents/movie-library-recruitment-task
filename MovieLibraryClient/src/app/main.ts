import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { usePrimeVue } from "./plugins/usePrimevue.ts";
import {useRouter} from "./plugins/useRouter.ts";
import {useEmitter} from "./plugins/useEmitter.ts";
import {useServiceInstantiator} from "./plugins/useServiceInstantiator.ts";
import {useToast} from "./plugins/useToast.ts";
import {useGridRenderers} from "./plugins/useGridRenderers.ts";
import './extensions/string-extensions.ts'
const app = createApp(App);

usePrimeVue(app);
useRouter(app);
const emitter = useEmitter(app);
useServiceInstantiator(app, emitter);
useToast(app);
useGridRenderers(app)
app.mount("#app");
