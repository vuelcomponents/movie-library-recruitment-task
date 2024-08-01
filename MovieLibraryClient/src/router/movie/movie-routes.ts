import {RouteRecordRaw} from "vue-router";

export const movieRoutes:RouteRecordRaw[] =[
    {
        path:'',
        component:() => import ("../../features/movie/MovieView.vue"),
        name:'Movies'
    }
]
