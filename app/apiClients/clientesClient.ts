import Cliente from "../entities/Cliente";
import http from "../http-common";

export const getAll = () => http.get<Array<Cliente>>("/client");

export const get = (id: String) => http.get<Array<Cliente>>(`/client/${id}`);

export const create = (cliente: Cliente) => {
  console.log(cliente);
  return http.post<Array<Cliente>>(`/client`, cliente);
};

export const update = (id: String, cliente: Cliente) => {
  console.log(cliente);
  return http.put<Array<Cliente>>(`/client/${id}`, cliente);
};
