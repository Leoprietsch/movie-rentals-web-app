import Locacao from "../entities/Locacao";
import http from "../http-common";

export const getAll = () => http.get<Array<Locacao>>("/rent");

export const get = (id: String | number) =>
  http.get<Array<Locacao>>(`/rent/${id}`);

export const create = (locacao: { idClient: number; idMovie: number }) =>
  http.post<Array<Locacao>>(`/rent`, locacao);

export const update = (
  id: String | number,
  locacao: { idClient: number; idMovie: number }
) => http.put<Array<Locacao>>(`/rent/${id}`, locacao);

export const exclude = (id: String | number) =>
  http.delete<Array<Locacao>>(`/rent/${id}`);

export const devolve = (id: String | number) =>
  http.put<Array<Locacao>>(`/rent/${id}/return`);
