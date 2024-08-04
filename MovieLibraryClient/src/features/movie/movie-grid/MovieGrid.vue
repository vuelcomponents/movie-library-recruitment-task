<script setup lang="ts">
import { AgGridVue } from "ag-grid-vue3";
import { ref } from "vue";
import { Movie } from "../../../entities/movie/Movie.ts";
import { movieGridColumns } from "./movie-grid-columns/movieGridColumns.ts";
import { GridPlus } from "../../../shared/grid/GridPlus.ts";
import { IGridPlus } from "../../../shared/grid/grid-interfaces/IGridPlus.ts";
import { AxiosResponse } from "axios";
import { Identified } from "../../../shared/types/Identified.ts";
import { MovieService } from "../../../entities/movie/MovieService.ts";
import { onMovieGridCellClicked } from "./movie-grid-events/onMovieGridCellClicked.ts";
import { Actionable } from "../../../shared/grid/grid-types/Actionable.ts";
import { CellClickedEvent } from "ag-grid-community";

const props = defineProps<{
  movieService: MovieService;
}>();
const emit = defineEmits<{
  updateMovie: [Identified<Movie>];
}>();
const grid = ref<IGridPlus<Movie>>(
  new GridPlus({
    events: {
      onCellClicked: (event: CellClickedEvent<Actionable<Movie>>) =>
        onMovieGridCellClicked(event, props.movieService, emit),
    },
    functions: {
      loadList: () => {
        props.movieService
          .getAll()
          .then((res: AxiosResponse<Array<Identified<Movie>>>) => {
            grid.value.api!.setGridOption("rowData", res.data);
          });
      },
    },
  }),
);
defineExpose({
  grid,
});
</script>

<template>
  <AgGridVue
    class="ag-theme-quartz h-screen-minus-headers"
    :rowData="grid.data"
    :grid-options="grid.options"
    rowSelection="multiple"
    animateRows="true"
    :columnDefs="movieGridColumns"
  />
</template>
