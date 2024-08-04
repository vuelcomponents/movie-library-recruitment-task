import { MovieService } from "../../../entities/movie/MovieService.ts";
import { IGridPlus } from "../../../shared/grid/grid-interfaces/IGridPlus.ts";
import { Movie } from "../../../entities/movie/Movie.ts";
import { AxiosResponse } from "axios";
import { Identified } from "../../../shared/types/Identified.ts";

export const handleIntegration = (
  service: MovieService,
  getGrid: () => IGridPlus<Movie>,
) => {
  return {
    integrate: () => {
      service
        .integrate()
        .then((res: AxiosResponse<Array<Identified<Movie>>>) => {
          if (res.status === 200) {
            getGrid().api!.applyTransaction({
              add: res.data!,
              addIndex: 0,
            });
          }
        });
    },
  };
};
