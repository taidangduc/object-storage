import { useEffect, useState } from "react";
import type { FileEntryModel } from "../types";
import { getList } from "../services/storage-service";

export function useStorage() {

    const [data, setData] = useState<FileEntryModel[]>([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState<Error | null>(null);

    const fetchData = async () => {
        setIsLoading(true);
        setError(null);
        try {
            const response = await getList();
            setData(response.data);
        }
        catch (error) {
            setError(error instanceof Error ? error : new Error("Unknown error"));
        }
        finally {
            setIsLoading(false);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    return {
        data,
        isLoading,
        error,
        refresh: fetchData
    };
}