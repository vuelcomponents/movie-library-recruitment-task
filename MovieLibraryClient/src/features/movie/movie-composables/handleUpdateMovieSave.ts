import { MovieService } from "../../../entities/movie/MovieService.ts";
import { Movie } from "../../../entities/movie/Movie.ts";
import { AxiosResponse } from "axios";
import { Identified } from "../../../shared/types/Identified.ts";
import { IGridPlus } from "../../../shared/grid/grid-interfaces/IGridPlus.ts";

export const handleUpdateMovieSave = (
  service: MovieService,
  getGrid: () => IGridPlus<Movie>,
  closeDialog: () => void,
) => {
  return {
    updateSave: (movie: Identified<Movie>) => {
      service.update(movie).then((res: AxiosResponse<Identified<Movie>>) => {
        if (res.status === 200) {
          getGrid().updateRowById(movie.id, res.data);
          closeDialog();
        }
      });
    },
  };
};
