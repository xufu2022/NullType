using Microsoft.AspNetCore.Components;
using NullWithWebAPI.Shared.DTO;
using System.Net.Http.Json;

namespace NullWithWebAPI.Client.Pages;

public partial class FetchData
{
    [Inject]
    public HttpClient Http { get; set; } = default!;

    [Inject]
    public ILogger<FetchData> Logger { get; set; } = default!;

    #region demo specific
    private bool forceException;
    private bool showEmptyState;
    #endregion
    private bool hasError;
    private bool isLoadingComplete;
    private Student[] students = Array.Empty<Student>();

    protected override async Task OnInitializedAsync() => await LoadData();

    async Task LoadData()
    {
        // clear any stale data from a retry
        students = Array.Empty<Student>();
        // show loading status
        isLoadingComplete = false;
        // clear loading status when complete
        isLoadingComplete = await TryLoadingData(
            onSuccess: OnSuccess, // branch on success
            onError: OnError // branch on error
            );

        void OnSuccess(Student[] data)
        {
            hasError = false;
            // do work with data
            students = data;

        }
        void OnError(Exception e)
        {
            hasError = true;
            // log message, don't share it with the user
            Logger.LogError(e.Message);
        }

        async Task<bool> TryLoadingData(Action<Student[]> onSuccess, Action<Exception> onError)
        {
            try
            {
                await Task.Delay(1000);
                var data = await Http.GetFromJsonAsync<Student[]>("api/students") ??
                    throw new NullReferenceException("Http request returned null");

                #region demo specific
                if (showEmptyState) data = Array.Empty<Student>();
                if (forceException) throw new Exception("For Demo");
                #endregion
                // process data
                onSuccess(data);
            }
            catch (Exception e)
            {
                // process error
                onError(e);
            }
            return true;
        }

    }
}
