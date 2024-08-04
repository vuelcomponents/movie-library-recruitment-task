import { type Ref, ref, watch } from "vue";
import { Movie } from "../../../entities/movie/Movie.ts";
import { Identified } from "../../../shared/types/Identified.ts";

export const handleUpdateMovieDialog = () => {
  const updateMovieDialogOpened = ref(false);
  const updatedMovie: Ref<Identified<Movie> | undefined> = ref();

  watch(updateMovieDialogOpened, (newVal) => {
    if (!newVal) {
      updatedMovie.value = undefined;
    }
  });

  return {
    updateMovieDialogOpened,
    updatedMovie,
    onUpdateMovieDialogOpen: (movie: Identified<Movie>) => {
      updateMovieDialogOpened.value = true;
      updatedMovie.value = movie;
    },
    onUpdateMovieDialogClose: () => {
      updateMovieDialogOpened.value = false;
      updatedMovie.value = undefined;
    },
  };
};
