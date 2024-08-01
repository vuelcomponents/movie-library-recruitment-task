import {ref} from "vue";

export const handleCreateMovieDialog = () => {
    const createMovieDialogOpened =  ref(false);
    return {
        createMovieDialogOpened,
        onCreateMovieDialogOpen: () =>{
            if(!createMovieDialogOpened.value){
                createMovieDialogOpened.value = true;
            }
        },
        onCreateMovieDialogClose: () =>{
            createMovieDialogOpened.value = false;
        }
    }
}