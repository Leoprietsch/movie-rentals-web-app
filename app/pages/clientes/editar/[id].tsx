import Title from "antd/lib/typography/Title";
import React, { useEffect, useState } from "react";
import { Form, Input, Button, DatePicker } from "antd";
import Cliente from "../../../entities/Cliente";
import { useRouter } from "next/router";
import moment, { Moment } from "moment";
import { get, update } from "../../../apiClients/clientesClient";

function EditarCliente() {
  const [form] = Form.useForm();
  const [cliente, setCliente] = useState<Cliente>();
  const router = useRouter();
  const { id } = router.query;

  useEffect(() => {
    get(id as String)
      .then((response: any) => {
        setCliente(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, [form, router.isReady]);

  useEffect(() => {
    form.setFieldsValue({
      nome: cliente?.nome,
      cpf: cliente?.cpf,
      dataNascimento: moment(cliente?.dataNascimento),
    });
  }, [cliente]);

  const onFinish = (cliente: Cliente) => {
    const dataNascimento = cliente.dataNascimento as unknown as Moment;
    cliente.dataNascimento = dataNascimento.toDate();
    update(id as String, cliente).then(() => router.push("/clientes"));
  };

  return (
    <>
      <Title>Edição de cliente</Title>
      <Form
        form={form}
        wrapperCol={{ span: 6 }}
        layout="vertical"
        size={"middle"}
        onFinish={onFinish}
      >
        <Form.Item required name="nome" label="Nome">
          <Input />
        </Form.Item>
        <Form.Item name="cpf" required label="CPF">
          <Input />
        </Form.Item>
        <Form.Item required name="dataNascimento" label="Data de Nascimento">
          <DatePicker format={"DD/MM/yyyy"} />
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

export default EditarCliente;
