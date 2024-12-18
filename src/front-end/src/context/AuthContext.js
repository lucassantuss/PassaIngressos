import { createContext, useCallback, useContext, useState, useEffect } from "react";
import api from "../services/api";

// Cria o contexto de autenticação
const AuthContext = createContext({});

const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(() => {
    const savedToken = localStorage.getItem("@PermissionPI:token");
    if (savedToken) {
      api.defaults.headers.authorization = `Bearer ${savedToken}`;
      return savedToken;
    }
    return null;
  });

// Função de login para autenticar o usuário e salvar o token
const signIn = useCallback(async ({ username, password }) => {
  try {
    const response = await api.post("/Acesso/Login", {
      Login: username,
      Senha: password,
    });
    
    const { token, idUsuarioLogado } = response.data;

    if (token) {
      setToken(token);
      localStorage.setItem("@PermissionPI:token", token);
      localStorage.setItem("@PermissionPI:idUsuarioLogado", idUsuarioLogado);
      api.defaults.headers.authorization = `Bearer ${token}`;
    } else {
      console.error("Token não encontrado na resposta da API.");
      throw new Error("Erro no login: token ausente");
    }
  } catch (error) {
    console.error("Erro no login:", error);
    throw new Error("Erro no login");
  }
}, []);
  
  // Função de logout
  const signOut = useCallback(() => {
    setToken(null);
    localStorage.removeItem("@PermissionPI:token");
    localStorage.removeItem("@PermissionPI:idUsuarioLogado");
    delete api.defaults.headers.authorization;
  }, []);

  // Verifica se o usuário está logado
  const userLogged = useCallback(() => {
    return !!localStorage.getItem("@PermissionPI:token");
  }, []);

  // Verificação do token ao carregar a aplicação
  useEffect(() => {
    const savedToken = localStorage.getItem("@PermissionPI:token");
    if (savedToken) {
      api.defaults.headers.authorization = `Bearer ${savedToken}`;
      setToken(savedToken);
    }
  }, []);

  return (
    <AuthContext.Provider value={{ token, signIn, signOut, userLogged }}>
      {children}
    </AuthContext.Provider>
  );
};

// Hook para acessar o contexto de autenticação
function useAuth() {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth deve ser usado dentro de um AuthProvider");
  }
  return context;
}

export { AuthProvider, useAuth };