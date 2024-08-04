<script setup lang="ts">
import { handleUpdateMovieDialog } from "./movie-composables/handleUpdateMovieDialog.ts";
import { handleCreateMovieDialog } from "./movie-composables/handleCreateMovieDialog.ts";
import MovieCreate from "./movie-create/MovieCreate.vue";
import MovieUpdate from "./movie-update/MovieUpdate.vue";
import MovieGrid from "./movie-grid/MovieGrid.vue";
import { inject, ref } from "vue";
import { ServiceInstantiator } from "../../shared/services/ServiceInstantiator.ts";
import { MovieService } from "../../entities/movie/MovieService.ts";
import ButtonHeader from "../../components/headers/ButtonHeader.vue";
import BodyContainer from "../../components/containers/BodyContainer.vue";
import Dialog from "primevue/dialog";
import { handleUpdateMovieSave } from "./movie-composables/handleUpdateMovieSave.ts";
import { handleCreateMovieSave } from "./movie-composables/handleCreateMovieSave.ts";
import { handleIntegration } from "./movie-composables/handleIntegration.ts";
import IconizedSpanResponsive from "../../components/responsives/IconizedSpanResponsive.vue";

const serviceInstantiator = inject<ServiceInstantiator>("ServiceInstantiator")!;
const movieService: MovieService =
  serviceInstantiator.create<MovieService>("MovieService")!;

const {
  updatedMovie,
  onUpdateMovieDialogOpen,
  updateMovieDialogOpened,
  onUpdateMovieDialogClose,
} = handleUpdateMovieDialog();

const {
  onCreateMovieDialogOpen,
  createMovieDialogOpened,
  onCreateMovieDialogClose,
} = handleCreateMovieDialog();

const movieGrid = ref<typeof MovieGrid>();

const { updateSave } = handleUpdateMovieSave(
  movieService,
  () => movieGrid.value!.grid,
  onUpdateMovieDialogClose,
);
const { createSave } = handleCreateMovieSave(
  movieService,
  () => movieGrid.value!.grid,
  onCreateMovieDialogClose,
);
const { integrate } = handleIntegration(
  movieService,
  () => movieGrid.value!.grid,
);
</script>

<template>
  <!-- body -->
  <BodyContainer>
    <ButtonHeader
      @onLeftButtonClick="onCreateMovieDialogOpen"
      @onRightButtonClick="integrate"
    >
      <template #leftButton>
        <IconizedSpanResponsive
          icon="mdi mdi-movie-plus-outline"
          text="Add new"
        />
      </template>
      <template #rightButton>
        <IconizedSpanResponsive
          icon="mdi mdi-cloud-download-outline"
          text="Integrate"
        />
      </template>
      <template #content> </template>
    </ButtonHeader>
    <MovieGrid
      :movieService="movieService"
      @updateMovie="onUpdateMovieDialogOpen"
      ref="movieGrid"
    />
  </BodyContainer>

  <!-- popups<dialog> -->
  <section>
    <Dialog v-model:visible="updateMovieDialogOpened" modal>
      <MovieUpdate
        v-if="updatedMovie"
        :movie="updatedMovie"
        @onMovieUpdateSave="updateSave"
      />
    </Dialog>
    <Dialog v-model:visible="createMovieDialogOpened" modal>
      <MovieCreate
        v-if="createMovieDialogOpened"
        @onMovieCreateSave="createSave"
      />
    </Dialog>
  </section>
</template>
