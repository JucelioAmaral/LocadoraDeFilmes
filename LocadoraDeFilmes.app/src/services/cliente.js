import { http } from "./config";

export default {
  salvar: (cliente) => {
    return http.post("​/api​/cliente​/AddCliente", cliente);
  },

  atualizar: (cliente) => {
    return http.put("​/api​/cliente​/UpdateCliente​/", cliente);
  },

  listar: () => {
    return http.get("/api/cliente/GetClient");
  },

  apagar: (cliente) => {
    return http.delete("/api/cliente/RemoveCLiente/", { data: cliente });
  },
};
