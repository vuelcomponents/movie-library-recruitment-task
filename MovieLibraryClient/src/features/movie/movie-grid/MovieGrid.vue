<script setup lang="ts">
import {AgGridVue} from "ag-grid-vue3";
import {ref} from "vue";
import {Movie} from "../../../entities/movie/Movie.ts";
import {movieGridColumns} from "./movie-grid-columns/movieGridColumns.ts";
import {GridPlus} from "../../../shared/grid/GridPlus.ts";
import {IGridPlus} from "../../../shared/grid/grid-interfaces/IGridPlus.ts";
import {AxiosResponse} from "axios";
import {Identified} from "../../../shared/types/Identified.ts";
import {MovieService} from "../../../entities/movie/MovieService.ts";

const props = defineProps<{
  movieService:MovieService
}>();

const grid = ref<IGridPlus<Movie>>(
    new GridPlus({
      events:{
          onCellClicked(event) {
            console.log(event)
          },
      },
      functions:{
        loadList:()=>{
          props.movieService.getAll().then((res:AxiosResponse<Array<Identified<Movie>>>)=>{
            grid.value.api!.setGridOption('rowData', res.data);
          })
        }
      }
    })
)

</script>

<template>
  <AgGridVue
      class="ag-theme-quartz h-full"
      :rowData="grid.data"
      style="height:500px; min-height:500px;"
      :grid-options="grid.options"
      rowSelection="multiple"
      animateRows="true"
      :columnDefs="movieGridColumns"
  />
</template>
