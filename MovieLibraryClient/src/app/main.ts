import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { usePrimeVue } from "./plugins/usePrimevue.ts";

const app = createApp(App);

usePrimeVue(app);

app.mount("#app");
