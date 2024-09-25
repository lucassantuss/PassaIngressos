import TituloInicial from "components/TituloInicial";
import BarraPesquisa from "components/BarraPesquisa";
import ProximosEventos from "components/ProximosEventos";
import SegurancaVendas from "components/SegurancaVendas";
import Feedback from "components/Feedback";

import styles from "./Inicio.module.css"

export default function Inicio() {
    return (
        <div>
          <TituloInicial/>
          <BarraPesquisa />
          <ProximosEventos />
          <SegurancaVendas />
          <Feedback />
        </div>
      );
}