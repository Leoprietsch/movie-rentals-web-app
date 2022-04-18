import Cliente from "../entities/Cliente";
import http from "../http-common";

export const getAll = () => http.get<Array<Cliente>>("/client");

export const get = (id: String | number) =>
  http.get<Array<Cliente>>(`/client/${id}`);

export const create = (cliente: Cliente) =>
  http.post<Array<Cliente>>(`/client`, cliente);

export const update = (id: String | number, cliente: Cliente) =>
  http.put<Array<Cliente>>(`/client/${id}`, cliente);

export const exclude = (id: String | number) =>
  http.delete<Array<Cliente>>(`/client/${id}`);
