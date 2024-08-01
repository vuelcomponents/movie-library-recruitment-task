import type {App} from "vue";
import ToastService from 'primevue/toastservice';
export function useToast(app:App){
    app.use(ToastService);
}