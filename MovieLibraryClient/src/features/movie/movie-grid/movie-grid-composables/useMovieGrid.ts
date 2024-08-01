import {type Ref, ref} from "vue";

export const useMovieGrid = () => {
    const rowData:Ref<Array<any>> = ref([])
    return {
        rowData,
        
    }
}