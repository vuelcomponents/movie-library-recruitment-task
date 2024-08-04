import { MovieService } from "../../../entities/movie/MovieService.ts";
import { Movie } from "../../../entities/movie/Movie.ts";
import { AxiosResponse } from "axios";
import { Identified } from "../../../shared/types/Identified.ts";
import { IGridPlus } from "../../../shared/grid/grid-interfaces/IGridPlus.ts";

export const handleCreateMovieSave = (
  service: MovieService,
  getGrid: () => IGridPlus<Movie>,
  closeDialog: () => void,
) => {
  return {
    createSave: (movie: Movie) => {
      service.create(movie).then((res: AxiosResponse<Identified<Movie>>) => {
        if (res.status === 200) {
          getGrid().api!.applyTransaction({
            add: [res.data!],
            addIndex: 0,
          });
          closeDialog();
        }
      });
    },
  };
};
