import Title from "antd/lib/typography/Title";
import React, { useEffect, useState } from "react";
import { Form, Button, Select } from "antd";
import { Moment } from "moment";
import Cliente from "../../../entities/Cliente";
import Filme from "../../../entities/Filmes";
import { getAll as getAllClients } from "../../../apiClients/clientesClient";
import { getAll as getAllMovies } from "../../../apiClients/filmesClient";
import { create } from "../../../apiClients/locacoesClient";
import { useRouter } from "next/router";
import Locacao from "../../../entities/Locacao";

function CadastrarLocacao() {
  const router = useRouter();
  const [filmes, setFilmes] = useState<Filme[]>([]);
  const [clientes, setClientes] = useState<Cliente[]>([]);

  useEffect(() => {
    getAllMovies()
      .then((response: any) => {
        setFilmes(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });

    getAllClients()
      .then((response: any) => {
        setClientes(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, []);

  const onFinish = (locacao: { idClient: number; idMovie: number }) =>
    create(locacao).then(() => router.push("/locacoes"));

  return (
    <>
      <Title>Cadastro de locação</Title>
      <Form
        wrapperCol={{ span: 6 }}
        layout="vertical"
        size={"middle"}
        onFinish={onFinish}
      >
        <Form.Item required name="idClient" label="Cliente">
          <Select
            showSearch
            placeholder="Escolha um cliente"
            optionFilterProp="children"
            filterOption={(input, option) =>
              (option?.children
                ?.toString()
                .toLowerCase()
                .indexOf(input.toLowerCase()) as number) >= 0
            }
          >
            {clientes.map((cliente) => (
              <Select value={cliente.id}>{cliente.nome}</Select>
            ))}
          </Select>
        </Form.Item>
        <Form.Item name="idMovie" required label="Filme">
          <Select
            showSearch
            placeholder="Escolha um filme"
            optionFilterProp="children"
            filterOption={(input, option) =>
              (option?.children
                ?.toString()
                .toLowerCase()
                .indexOf(input.toLowerCase()) as number) >= 0
            }
          >
            {filmes.map((filme) => (
              <Select value={filme.id}>{filme.titulo}</Select>
            ))}
          </Select>
        </Form.Item>
        <Form.Item>
          <Button type="primary" htmlType="submit">
            Salvar
          </Button>
        </Form.Item>
      </Form>
    </>
  );
}

export default CadastrarLocacao;
