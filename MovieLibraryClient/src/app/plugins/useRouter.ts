import {type App} from "vue";
import {createRouter, createWebHistory} from "vue-router";
import {main} from "../../router/main.ts";
import {movieRoutes} from "../../router/movie/movie-routes.ts";


export function useRouter(app:App){
    app.use(createRouter({
        history: createWebHistory(import.meta.env.BASE_URL),
        routes:[
            {...main,
                children:[
                    ...movieRoutes
                ]
            }
        ]
    }));
}