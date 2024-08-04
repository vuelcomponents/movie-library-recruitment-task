import type {App} from "vue";
import MovieGridRateRenderer from "../../features/movie/movie-grid/movie-grid-renderers/MovieGridRateRenderer.vue";
import GridRemovalRenderer from "../../shared/grid/grid-global-renderers/GridRemovalRenderer.vue";
import GridUpdateRenderer from "../../shared/grid/grid-global-renderers/GridUpdateRenderer.vue";

export function useGridRenderers(app: App): void {
   app.component("MovieGridRateRenderer", MovieGridRateRenderer)
   app.component("GridRemovalRenderer", GridRemovalRenderer)
   app.component("GridUpdateRenderer", GridUpdateRenderer)
}
