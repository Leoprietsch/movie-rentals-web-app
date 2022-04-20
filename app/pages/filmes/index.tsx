import { Button, Form, message, Table, Upload } from "antd";
import { ColumnsType } from "antd/lib/table";
import Title from "antd/lib/typography/Title";
import { VideoCameraAddOutlined } from "@ant-design/icons";
import React, { useEffect, useState } from "react";
import Filme from "../../entities/Filmes";
import { importMovies, getAll } from "../../apiClients/filmesClient";
import { UploadFile } from "antd/lib/upload/interface";

function Filmes() {
  const [filmes, setFilmes] = useState<Filme[]>([]);
  const [fileList, setFileList] = useState<UploadFile<any>[]>([]);

  useEffect(() => {
    getAll()
      .then((response) => {
        console.log(response.data);
        setFilmes(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, []);

  const columns: ColumnsType<Filme> = [
    {
      title: "Título",
      dataIndex: "titulo",
      key: "titulo",
    },
    {
      title: "Classificação Indicativa",
      dataIndex: "classificacaoIndicativa",
      key: "classificacaoIndicativa",
    },
    {
      title: "Lançamento",
      dataIndex: "lancamento",
      key: "lancamento",
      render: (lancamento: boolean) => {
        if (lancamento) return "Sim";
        else return "Não";
      },
    },
  ];

  return (
    <>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <Title>Filmes</Title>
        <Form>
          <Upload
            fileList={fileList}
            beforeUpload={(file) => {
              const isCSV = file.type === "text/csv";
              if (!isCSV) {
                message.error(`${file.name}  não é do tipo .csv`);
              }
              return isCSV || Upload.LIST_IGNORE;
            }}
            onChange={(info) => {
              setFileList(info?.fileList);
              const file = info?.fileList[0];

              if (file?.status === "done" && file?.originFileObj) {
                importMovies(file.originFileObj)
                  .then(() =>
                    getAll().then((response) => setFilmes(response.data))
                  )
                  .catch((error) => message.error(error.response.data.error))
                  .finally(() => {
                    setFileList([]);
                  });
              }
            }}
            accept="text/csv"
            maxCount={1}
          >
            <Button
              type="primary"
              size="large"
              icon={<VideoCameraAddOutlined />}
            >
              Importar filmes
            </Button>
          </Upload>
        </Form>
      </div>
      <Table columns={columns} dataSource={filmes} />
    </>
  );
}

export default Filmes;
