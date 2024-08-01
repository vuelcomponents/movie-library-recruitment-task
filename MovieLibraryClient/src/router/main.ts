import {RouteRecordRaw} from "vue-router";

export const main:RouteRecordRaw =
{
    name:'Main',
    component: () => import("../features/main/MainView.vue"),
    path:'/'
};
