import {computed, type Ref, ref} from "vue";
import {Movie} from "../../../entities/movie/Movie.ts";

export const handleUpdateMovieDialog = () => {
    const updateMovieDialogOpenedRef =  ref(false);
    const updatedMovie:Ref<Movie |undefined> = ref();
    return {
        updateMovieDialogOpenedRef,
        updatedMovie,
        onUpdateMovieDialogOpen: (movie:Movie) =>{
            updateMovieDialogOpenedRef.value = true;
            updatedMovie.value = movie;
        },
        onUpdateMovieDialogClose: () =>{
            updateMovieDialogOpenedRef.value = false;
            updatedMovie.value = undefined;
        },
        updateMovieDialogOpened: computed(()=> updatedMovie && updateMovieDialogOpenedRef.value )
    }
}