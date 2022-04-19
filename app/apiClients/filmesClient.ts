import axios from "axios";
import Filme from "../entities/Filmes";
import http from "../http-common";

export const getAll = () => http.get<Array<Filme>>("/movie");

export const importMovies = (blob: Blob) => {
  let formData = new FormData();
  formData.append("file", blob);

  return axios({
    method: "post",
    url: "http://localhost:5000/movie",
    data: formData,
    headers: {
      "Content-Type": `multipart/form-data`,
    },
  });
};
