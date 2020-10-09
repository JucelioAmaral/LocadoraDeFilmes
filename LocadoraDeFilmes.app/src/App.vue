<template>
  <div id="app">
    <nav>
      <div class="nav-wrapper blue darken-1">
        <a href="#" class="brand-logo center">Cliente</a>
      </div>
    </nav>

    <div class="container">
      <ul>
        <li v-for="(erro, index) of errors" :key="index">
          campo
          <b>{{erro.field}}</b>
          - {{erro.defaultMessage}}
        </li>
      </ul>

      <table>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>CPF</th>
            <th>Data de nascimento</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="cliente of clientes" :key="cliente.id">
            <td>{{ cliente.id }}</td>
            <td>{{ cliente.nome }}</td>
            <td>{{ cliente.cpf }}</td>
            <td>{{ cliente.datadenascimento}}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import Cliente from "./services/cliente";

export default {
  name: "app",
  data() {
    return {
      cliente: {
        id: "",
        nome: "",
        cpf: "",
        datadenascimento: "",
      },
      clientes: [],
      errors: [],
    };
  },

  mounted() {
    this.listar();
  },

  methods: {
    listar() {
      Cliente.listar()
        .then((resposta) => {
          this.clientes = resposta.data;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    salvar() {
      if (!this.cliente.id) {
        Cliente.salvar(this.cliente)
          .then((resposta) => {
            this.cliente = {};
            alert("Cadastrado com sucesso!");
            this.listar();
            this.errors = {};
          })
          .catch((e) => {
            this.errors = e.response.data.errors;
          });
      } else {
        Cliente.atualizar(this.cliente)
          .then((resposta) => {
            this.cliente = {};
            this.errors = {};
            alert("Atualizado com sucesso!");
            this.listar();
          })
          .catch((e) => {
            this.errors = e.response.data.errors;
          });
      }
    },

    editar(cliente) {
      this.cliente = cliente;
    },

    remover(cliente) {
      if (confirm("Deseja excluir o cliente?")) {
        cliente.apagar(cliente)
          .then((resposta) => {
            this.listar();
            this.errors = {};
          })
          .catch((e) => {
            this.errors = e.response.data.errors;
          });
      }
    },
  },
};
</script>

<style>
</style>
