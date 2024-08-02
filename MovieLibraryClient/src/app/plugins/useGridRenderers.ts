import type {App} from "vue";
import MovieGridRateRenderer from "../../features/movie/movie-grid/movie-grid-renderers/MovieGridRateRenderer.vue";

export function useGridRenderers(app: App): void {
   app.component("MovieGridRateRenderer", MovieGridRateRenderer)
}
