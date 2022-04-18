import Cliente from "../entities/Cliente";
import http from "../http-common";

export const getAll = () => http.get<Array<Cliente>>("/client");
