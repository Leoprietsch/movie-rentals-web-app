import Filme from "../entities/Filmes";
import http from "../http-common";

export const getAll = () => http.get<Array<Filme>>("/movie");
