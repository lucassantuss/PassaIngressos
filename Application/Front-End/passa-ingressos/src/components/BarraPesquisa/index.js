import Botao from 'components/Botao';
import styles from './BarraPesquisa.module.css';

const BarraPesquisa = () => {

  return (
    <div className={styles.searchBox}>
        <input
            type="text"
            placeholder="Digite o nome do evento.."
            className={styles.searchInput}
        />
        <Botao cn={styles.searchButton} conteudo="Pesquisar"/>
    </div>
  );
};

export default BarraPesquisa;