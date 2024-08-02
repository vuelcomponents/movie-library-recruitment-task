<script setup lang="ts">
import {handleUpdateMovieDialog} from "./movie-composables/handleUpdateMovieDialog.ts";
import {handleCreateMovieDialog} from "./movie-composables/handleCreateMovieDialog.ts";
import MovieCreate from "./movie-create/MovieCreate.vue";
import MovieUpdate from "./movie-update/MovieUpdate.vue";
import MovieGrid from "./movie-grid/MovieGrid.vue";
import {inject} from "vue";
import {ServiceInstantiator} from "../../shared/services/ServiceInstantiator.ts";
import {MovieService} from "../../entities/movie/MovieService.ts";

const serviceInstantiator = inject<ServiceInstantiator>('ServiceInstantiator')!;
const movieService:MovieService = serviceInstantiator.create<MovieService>('MovieService')!

const {
  updatedMovie,
  onUpdateMovieDialogOpen,
  onUpdateMovieDialogClose,
  updateMovieDialogOpened
} = handleUpdateMovieDialog()

const {
  onCreateMovieDialogOpen,
  onCreateMovieDialogClose,
  createMovieDialogOpened
} = handleCreateMovieDialog();
/* d */
console.log({ updatedMovie, onUpdateMovieDialogOpen, onUpdateMovieDialogClose, updateMovieDialogOpened } );
console.log({ onCreateMovieDialogOpen, onCreateMovieDialogClose, createMovieDialogOpened } )
/* e */

</script>

<template>
  <section>
    <MovieCreate v-if="createMovieDialogOpened"/>
    <MovieUpdate v-if="updateMovieDialogOpened"/>
  </section>
  <section>
    <MovieGrid :movieService="movieService"/>
  </section>
</template>

